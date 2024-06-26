﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using NuGet.Protocol;
using Portfolio.DataAccess.Repository.IRepository;
using Portfolio.Models;
using Portfolio.Models.ViewModels;
using System.Configuration;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace PortfolioWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BioController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
        public Biography Bio { get; set; }

        public IActionResult Index()
        {
            Bio = _unitOfWork.Biography.GetAll().FirstOrDefault();
            return View(Bio);
        }

        [HttpPost]
        public IActionResult Upsert(Biography updatedBio, List<IFormFile> files)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");

            if (files != null && files.Count > 0)
            {
                var file = files[0];
                var oldBio = _unitOfWork.Biography.Get(b => b.Id == updatedBio.Id);

                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"img\bio\");
                var oldImagePath = Path.Combine(imagePath + oldBio.Image);

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

                updatedBio.Image = file.FileName;

                using var fileStream = new FileStream(Path.Combine(imagePath, file.FileName), FileMode.Create);
                file.CopyTo(fileStream);
            }

            _unitOfWork.Biography.Update(updatedBio);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
