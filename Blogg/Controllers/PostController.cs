using Blogg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Post post = db.Posts.Find(id);
            if (post == null)
                return HttpNotFound();
            return View(post);
        }

        // GET: Post/Create
        [HttpGet]
        public ActionResult Create(int? id)
        {
           // int? par = id;
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
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Post post = db.Posts.Find(id);
            post.ID = id;
            if (post == null)
                return HttpNotFound();
            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(Post post)
        {
             try
            {
                if(ModelState.IsValid)
                {
                    db.Entry(post).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Post", new { id = post.BlogID });
                }
                return View(post);
            }
            catch
            {
                return View();
            }
        
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Post post = db.Posts.Find(id);
            if (post == null)
                return HttpNotFound();
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Post po)
        {
            try
            {
                Post post = new Post();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    post = db.Posts.Find(id);
                    if (post == null)
                        return HttpNotFound();


                    db.Posts.Remove(post);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(post);
            }
            catch
            {
                return View();
            }
        }
    }
}
