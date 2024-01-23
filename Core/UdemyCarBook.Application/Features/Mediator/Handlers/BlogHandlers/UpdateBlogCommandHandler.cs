﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.BlogCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogID);
            value.AuthorID = request.AuthorID;
            value.CreatedDate = request.CreatedDate;
            value.CategoryId = request.CategoryId;
            value.Title = request.Title;
            value.CoverImageUrl = request.CoverImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
