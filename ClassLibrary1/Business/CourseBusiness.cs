using AkfnyServices.MediatR.CourseEntity.Commands;
using AkfnyServices.MediatR.TrainerEntity.Commands;
using AutoMapper;
using Data.Entities;
using Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AkfnyServices.Business
{

    public interface ICourseBusiness
    {
        Task<bool> AddCourse(AddCourseCommand model);
        Task<bool> EditCourse(EditCourseCommand model);
    }
    public class CourseBusiness : ICourseBusiness
    {
        public readonly IRepository<Course, int> _courseRepository;
        public readonly IRepository<CourseTargetedFinal, int> _courseTargetedFinalRepository;
        public readonly IMapper _mapper;


        public CourseBusiness(IRepository<Course, int> courseRepository, IRepository<CourseTargetedFinal, int> courseTargetedFinalRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _courseTargetedFinalRepository = courseTargetedFinalRepository;
            _mapper = mapper;
        }
        
        public async Task<bool> AddCourse(AddCourseCommand model)
        {
            var course = _mapper.Map<Course>(model);
            //course.Course_Img = Convert.FromBase64String(model.Img_Base64);
            var courseId = await _courseRepository.Add(course);
            foreach (var item in model.InterestId)
            {
                await _courseTargetedFinalRepository.Add(new CourseTargetedFinal { CourseId = courseId, MajorInterestId = int.Parse(item.Key), SubInterestId = item.Value, InsertCode = model.InsertCode });
            }
            return true;
        }

        public async Task<bool> EditCourse(EditCourseCommand model)
        {
            var course = _mapper.Map<Course>(model);
            _courseRepository.Update(course);
            await _courseRepository.SaveChangesAsync();

            if (model.InterestId != null)
            {
                var currentInterests = _courseTargetedFinalRepository.GetAll(s=> s.CourseId == course.Id).ToList();
                var deletedInterests = currentInterests.Where(s => model.InterestId.All(x => int.Parse(x.Key) != s.MajorInterestId && x.Value != s.SubInterestId)).ToList();
                foreach (var interest in deletedInterests)
                {
                    _courseTargetedFinalRepository.Delete(interest);
                }
                var newInterests = model.InterestId.Where(x => currentInterests.All(s => int.Parse(x.Key) != s.MajorInterestId && x.Value != s.SubInterestId));
                foreach (var dic in newInterests)
                {
                    await _courseTargetedFinalRepository.Add(new CourseTargetedFinal { CourseId = course.Id, MajorInterestId = int.Parse(dic.Key), SubInterestId = dic.Value, InsertCode = model.InsertCode });
                };
                await _courseTargetedFinalRepository.SaveChangesAsync();
            }
            else
            {
                var currentInterests = _courseTargetedFinalRepository.GetAll(s => s.CourseId == course.Id);
                foreach (var interest in currentInterests)
                {
                    _courseTargetedFinalRepository.Delete(interest);
                }
                await _courseTargetedFinalRepository.SaveChangesAsync();
            }

            return true;
        }
    }
}
