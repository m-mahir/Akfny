using AkfnyServices.Business;
using AkfnyServices.MediatR.CourseSuggestionEntity.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AkfnyServices.MediatR.CourseSuggestionEntity.Handlers
{

    public class AddCourseSuggestionHandler : IRequestHandler<AddCourseSuggestionCommand, bool>
    {
        public ICourseSuggestionBusiness _CourseSuggestionBusiness;
        public AddCourseSuggestionHandler(ICourseSuggestionBusiness CourseSuggestionBusiness)
        {
            _CourseSuggestionBusiness = CourseSuggestionBusiness;
        }

        async Task<bool> IRequestHandler<AddCourseSuggestionCommand, bool>.Handle(AddCourseSuggestionCommand request, CancellationToken cancellationToken)
        {
            await _CourseSuggestionBusiness.AddCourseSuggestion(request);
            return true;
        }
    }

}
