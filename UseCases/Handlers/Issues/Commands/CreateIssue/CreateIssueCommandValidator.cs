﻿using FluentValidation;

namespace UseCases.Handlers.Issues.Commands.CreateIssue
{
    public class CreateIssueCommandValidator : AbstractValidator<CreateIssueCommand>
    {
        public CreateIssueCommandValidator()
        {
            RuleFor(p => p.Name).MaximumLength(100).NotEmpty();
        }
    }
}