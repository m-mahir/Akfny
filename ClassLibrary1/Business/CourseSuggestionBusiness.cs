using AkfnyServices.MediatR.CourseSuggestionEntity.Commands;
using AkfnyServices.MediatR.TrainerEntity.Commands;
using AutoMapper;
using Data.Entities;
using Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AkfnyServices.Business
{

    public interface ICourseSuggestionBusiness
    {
        Task<bool> AddCourseSuggestion(AddCourseSuggestionCommand model);
        Task<bool> EditCourseSuggestion(EditCourseSuggestionCommand model);
        Task<CourseSuggestion> ChangeCourseSuggestion(ChangeCourseSuggestionCommand model);
    }
    public class CourseSuggestionBusiness : ICourseSuggestionBusiness
    {
        public readonly IRepository<CourseSuggestion, int> _CourseSuggestionRepository;
        public readonly IMapper _mapper;


        public CourseSuggestionBusiness(IRepository<CourseSuggestion, int> CourseSuggestionRepository, IMapper mapper)
        {
            _CourseSuggestionRepository = CourseSuggestionRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddCourseSuggestion(AddCourseSuggestionCommand model)
        {
            var CourseSuggestion = _mapper.Map<CourseSuggestion>(model);
            var CourseSuggestionId = await _CourseSuggestionRepository.Add(CourseSuggestion);
            return true;
        }

        public async Task<bool> EditCourseSuggestion(EditCourseSuggestionCommand model)
        {
            var courseSuggestion = _mapper.Map<CourseSuggestion>(model);
            _CourseSuggestionRepository.Update(courseSuggestion);
            await _CourseSuggestionRepository.SaveChangesAsync();
            return true;
        }

        public async Task<CourseSuggestion> ChangeCourseSuggestion(ChangeCourseSuggestionCommand model)
        {
            var trainee = _CourseSuggestionRepository.GetAll().FirstOrDefault(o => o.Id == model.Id);
            if (trainee != null)
            {
                trainee.StatusId = model.StatusId;
                if (_CourseSuggestionRepository.SaveChanges() <= 0)
                    throw new Exception("");
            }
            return trainee;
        }
    }
}
