﻿using Koinonia.Application.ViewModels.Comments;
using Koinonia.Domain.Interface;
using Koinonia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koinonia.Application.Interface
{
    public interface ICommentsService : IRepository<Comments>
    {
        Task<Comments> CommentOnPost(CommentsViewModel model);
        IQueryable<Comments> GetPostComments(Guid PostId);
        void DeleteComment(Guid commentId);
    }
}
