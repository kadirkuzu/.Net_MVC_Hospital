﻿using Hospital.Models;
using Hospital.Models.Hospital.ResponseDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hospital.MVC.Admin.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly HttpClient http;

        public DepartmentController(IHttpClientFactory factory)
        {
            http = factory.CreateClient("httpClient");
        }

        public async Task<ActionResult> Index()
        {
            var response = await http.GetAsync("departments");
            IEnumerable<GetDepartmentResponseDto>? departments;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                departments = JsonConvert.DeserializeObject<List<GetDepartmentResponseDto>>(json);
            }
            else
            {
                departments = Enumerable.Empty<GetDepartmentResponseDto>();
                ModelState.AddModelError(string.Empty, "Error");
            }
            return View(departments);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
