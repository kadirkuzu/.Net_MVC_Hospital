﻿using Hospital.Models.Hospital.ResponseDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hospital.MVC.Admin.Controllers
{
    [HospitalAuthorize]
    public class ClinicController : Controller
    {
        private readonly HttpClient http;

        public ClinicController(IHttpClientFactory factory)
        {
            http = factory.CreateClient("httpClient");
        }

        public async Task<ActionResult> Index()
        {
            var response = await http.GetAsync("clinics");
            IEnumerable<GetClinicResponseDto>? clinics;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                clinics = JsonConvert.DeserializeObject<List<GetClinicResponseDto>>(json);
            }
            else
            {
                clinics = Enumerable.Empty<GetClinicResponseDto>();
                ModelState.AddModelError(string.Empty, "Error");
            }
            return View(clinics);
        }

        // GET: ClinicController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClinicController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClinicController/Create
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

        // GET: ClinicController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClinicController/Edit/5
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

        // GET: ClinicController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClinicController/Delete/5
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
