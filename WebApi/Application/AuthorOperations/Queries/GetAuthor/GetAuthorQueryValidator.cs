using FluentValidation;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthor
{
    public class GetAuthorQueryValidator : AbstractValidator<GetAuthorQuery>
    {           
        public GetAuthorQueryValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThan(0).NotEmpty();
        }
    }
}