using AkfnyServices.Business;
using AkfnyServices.MediatR.CourseSuggestionEntity.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AkfnyServices.MediatR.CourseSuggestionEntity.Handlers
{

    public class EditCourseSuggestionHandler : IRequestHandler<EditCourseSuggestionCommand, bool>
    {
        public ICourseSuggestionBusiness _CourseSuggestionBusiness;
        public EditCourseSuggestionHandler(ICourseSuggestionBusiness CourseSuggestionBusiness)
        {
            _CourseSuggestionBusiness = CourseSuggestionBusiness;
        }

        async Task<bool> IRequestHandler<EditCourseSuggestionCommand, bool>.Handle(EditCourseSuggestionCommand request, CancellationToken cancellationToken)
        {
            await _CourseSuggestionBusiness.EditCourseSuggestion(request);
            return true;
        }
    }

}
