﻿using ELibrary.Application.Features.Mediator.Commands.UserBookCommands;
using ELibrary.Application.Features.Mediator.Queries.UserBookQueries;
using ELibrary.Application.Features.Mediator.Results.UserBookResults;
using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebUI.Controllers
{
    public class UserLibraryController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly HttpClient _httpClient;
        private readonly IBookRepository _bookRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        public UserLibraryController(UserManager<ApplicationUser> userManager, HttpClient httpClient, IBookRepository bookRepository, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _httpClient = httpClient;
            _bookRepository = bookRepository;
            _httpClientFactory = httpClientFactory;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyLibrary()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            int userId = user.Id;

            var responseMessage = await _httpClient.GetAsync($"https://localhost:7220/api/UserBooks/user/{userId}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var userBooks = await responseMessage.Content.ReadFromJsonAsync<List<GetUserBookByUserIdQueryResult>>();
                return View(userBooks);
            }
            else
            {
                var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                return BadRequest($"API Error: {errorMessage}");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddUserBookMyLibrary()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var responseMessage1 = await _httpClient.GetAsync("https://localhost:7220/api/Books");
            var responseMessage2 = await _httpClient.GetAsync("https://localhost:7220/api/Categories");
            var responseMessage3 = await _httpClient.GetAsync("https://localhost:7220/api/Authors");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var books = await responseMessage1.Content.ReadFromJsonAsync<List<Book>>();
                var categories=await responseMessage2.Content.ReadFromJsonAsync<List<Category>>();
                var authors=await responseMessage3.Content.ReadFromJsonAsync<List<Author>>();

                ViewBag.Books = books;
                ViewBag.Categories = categories;
                ViewBag.Authors = authors;

                return View(); 
            }
            else
            {
                var errorMessage = await responseMessage1.Content.ReadAsStringAsync();
                return BadRequest($"API Error: {errorMessage}");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUserBookMyLibrary(CreateUserBookCommand command)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            command.UserId = user.Id; 
            command.DateAdded = DateTime.UtcNow;

            var responseMessage = await _httpClient.PostAsJsonAsync("https://localhost:7220/api/UserBooks", command);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MyLibrary");
            }
            else
            {
                var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                return BadRequest($"API Error: {errorMessage}");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteUserBook(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7220/api/UserBooks?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MyLibrary");
            }

            return View();
        }

      

        [HttpGet]
        public IActionResult Filter()
        {
            return View();
        }

        // Kitapları Tarih Aralığına Göre Filtreleme Aksiyonu
        [HttpPost]
        public async Task<IActionResult> Filter(DateTime startDate, DateTime endDate)
        {
            if (startDate == default || endDate == default)
            {
                ModelState.AddModelError("", "Lütfen geçerli bir tarih aralığı girin.");
                return View();
            }

            var books = await _bookRepository.GetBooksByPublishedDateAsync(startDate, endDate);
            return View("Filter", books);
        }


    }

}
