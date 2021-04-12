using Git.Data;
using Git.Services;
using Git.ViewModels.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoryService;

        public RepositoriesController(IRepositoriesService repositoryService)
        {
            this.repositoryService = repositoryService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var repositories = this.repositoryService.GetAll();

            return this.View(repositories);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, string repositoryType)
        {

            if (this.GetUserId() == null)
            {
                return this.Redirect("/Users/Login");
            }
            if (name == null)
            {
                return this.Error("Invalid name");
            }
            bool IsPublic;
            if (repositoryType == "Public")
            {
                IsPublic = true;
            }
            else if (repositoryType == "Private")
            {
                IsPublic = false;
            }
            else
            {
                return this.Error("Invalid type");
            }
            var userId = this.GetUserId();
            this.repositoryService.AddRepository(name,IsPublic,userId);
            return this.Redirect("/Repositories/All");
        }

    }
}
