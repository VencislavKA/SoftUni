using Git.Data;
using Git.Services;
using Git.ViewModels.Commits;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitService commitService;

        public CommitsController(ICommitService commitService)
        {
            this.commitService = commitService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var commits = this.commitService.GetAll();

            return this.View(commits);
        }
        
        public HttpResponse Create(string id)
        {
            
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var repository = this.commitService.GetRepository(id);
            return this.View(repository);
        }

        [HttpPost]
        public HttpResponse Create(string description)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            if(description == null)
            {
                return this.Error("Invalid description");
            }
            this.commitService.Create(description);
            return this.Redirect("/Repositories/All");
        }
        public HttpResponse Delete(Commit commit) 
        {
            this.commitService.Delete(commit);
            return this.Redirect("/Commits/All");
        }
    }
}
