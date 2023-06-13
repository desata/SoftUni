using Forum.App.Data;
using Forum.App.Data.Models;
using Forum.App.Data.Models.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Forum.App.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumAppDbContext data;
        public PostController(ForumAppDbContext _data)
        {
            data = _data; 
        }

        public async Task<IActionResult> All()
        {
            var posts = await data.Posts
                .Select(p => new PostViewModel()
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content
            })
                .ToListAsync();
            return View(posts);
        }


        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };

            await data.Posts.AddAsync(post);
            await data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var post = await data.Posts.FindAsync(id);

            var postModel = new PostFormModel()
            {
                Title = post.Title,
                Content = post.Content
            };

            return View(postModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormModel model)
        {
            var post = await data.Posts.FindAsync(id);

            post.Title = model.Title;
            post.Content = model.Content;

            await data.SaveChangesAsync();

            return RedirectToAction("All");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id, PostFormModel model)
        {
            var post = await data.Posts.FindAsync(id);

            data.Posts.Remove(post);

            await data.SaveChangesAsync();

            return RedirectToAction("All");
        }
    }
}
