using Blogg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blogg.Controllers
{
    public class BlogController : Controller
    {
        private DatabaseModel db = new DatabaseModel();

        // GET: Blog
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }
        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
                return HttpNotFound();
            return View(blog);
        }

        // GET: Blog/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(Blog blog)
        {
        
            try
            {
                if(ModelState.IsValid)
                {
                    db.Blogs.Add(blog);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                // TODO: Add insert logic here
                return View(blog);
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
                return HttpNotFound();
            return View(blog);
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(Blog blog)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Entry(blog).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(blog);
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
                return HttpNotFound();
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Blog blo)
        {
            try
            {              
                Blog blog = new Blog();
                if (ModelState.IsValid)
                {
                    if(id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                blog = db.Blogs.Find(id);
                if(blog == null)
                    return HttpNotFound();


                    db.Blogs.Remove(blog);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(blog);
            }
            catch
            {
                return View();
            }
        }
    }
}
