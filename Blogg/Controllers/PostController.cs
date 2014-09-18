using Blogg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogg.Controllers
{
    public class PostController : Controller
    {
        private DatabaseModel db = new DatabaseModel();

        // GET: Post
        public ActionResult Index(int? id)
        {
            ViewBag.parentID = id;
            int parentID = Convert.ToInt32(id);
            var post = db.Posts.Where(i => i.BlogID == parentID);
            return View(post);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        [HttpGet]
        public ActionResult Create(int? id)
        {
            int? par = id;
            var post = new Post();
            post.ID = Convert.ToInt32(id);

            return View(post);
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(Post p, int id)
        {
            var post = new Post
            {
                title = p.title,
                Text = p.Text,
                Author = p.Author,
                BlogID = id
            };
            try
            {
                if (ModelState.IsValid)
                
                {
                    //db.Posts.Where(post => post.BlogID == parentID)
                    db.Posts.Add(post);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Post", new { id = id });

                }
                // TODO: Add insert logic here
                return View();
            }
            catch
            {
                return View();
            
            }
             
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
