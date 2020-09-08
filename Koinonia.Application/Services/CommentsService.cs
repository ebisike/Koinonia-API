﻿using Koinonia.Application.Interface;
using Koinonia.Application.ViewModels.Comments;
using Koinonia.Domain.Interface;
using Koinonia.Domain.Models;
using Koinonia.Infra.Data.Context;
using Koinonia.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koinonia.Application.Services
{
    public class CommentsService : Repository<Comments>, ICommentsService
    {
        private readonly IRepository<Comments> commentRepo;

        public CommentsService(KoinoniaDbContext contex, IRepository<Comments> CommentRepo) : base(contex)
        {
            commentRepo = CommentRepo;
        }

        public async Task<Comments> CommentOnNews(CommentsViewModel model)
        {
            var usercomment = new Comments()
            {
                NewsId = model.PostId,
                userId = model.userId,
                DateCommented = DateTime.Now,
                Usercomment = model.UserComment
            };

            await commentRepo.AddNewAsync(usercomment);
            await commentRepo.SaveChangesAsync();
            return usercomment;
        }

        public async Task<Comments> CommentOnPost(CommentsViewModel model)
        {
            var usercomment = new Comments()
            {
                Usercomment = model.UserComment,
                PostId = model.PostId,
                userId = model.userId,
                DateCommented = DateTime.Now
            };

            await commentRepo.AddNewAsync(usercomment);
            await commentRepo.SaveChangesAsync();
            return usercomment;
        }

        public async Task<Comments> CommentOnTestimony(CommentsViewModel model)
        {
            var usercomment = new Comments()
            {
                Usercomment = model.UserComment,
                userId = model.userId,
                PostId = model.PostId,
                DateCommented = DateTime.Now
            };
            await commentRepo.AddNewAsync(usercomment);
            await commentRepo.SaveChangesAsync();
            return usercomment;
        }

        public IQueryable<Posts> GetPostComments(Guid PostId)
        {
            var comments = _context.Comment
                .Where(x => x.Id == PostId)
                .Select(x => x.post)
                .Include(x => x.User);
            return comments;
        }
    }
}
