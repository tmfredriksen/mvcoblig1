using Blogg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Postg.Controllers
{
    public class PostController : Controller
    {        
        DatabaseModel db = new DatabaseModel();
        // GET: Post
        public ActionResult Index(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // List<Post> Post;
            //Post Post = db.Posts.Find(id);
            // if (Post == null)
            //   return HttpNotFound();

            return View(db.Posts.ToList());          
             
        }

        public ActionResult Open(int? id)
        {
            return View(db.Posts.ToList());
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(Post Post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Posts.Add(Post);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                // TODO: Add insert logic here
                return View(Post);
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Post Post = db.Posts.Find(id);
            if (Post == null)
                return HttpNotFound();
            return View(Post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(Post Post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(Post).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(Post);
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Post Post = db.Posts.Find(id);
            if (Post == null)
                return HttpNotFound();
            return View(Post);
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Post blo)
        {
            try
            {
                Post Post = new Post();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    Post = db.Posts.Find(id);
                    if (Post == null)
                        return HttpNotFound();


                    db.Posts.Remove(Post);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(Post);
            }
            catch
            {
                return View();
            }
        }
    }
}
