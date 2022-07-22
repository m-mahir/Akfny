using AkfnyServices.MediatR.CourseEntity.Commands;
using AkfnyServices.MediatR.CourseSuggestionEntity.Commands;
using AkfnyServices.MediatR.TraineeEntity.Commands;
using AkfnyServices.MediatR.TrainerEntity.Commands;
using AutoMapper;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkfnyServices.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Trainer, CreateTrainerCommand>();
            //.ForMember(s => s.Code, d => d.MapFrom(o => o.Code));
            //CreateMap<CreateTrainerCommand,Trainer>();
            CreateMap<AddCourseCommand, Course>().ForMember(dest => dest.Course_Img, opt => opt.MapFrom(src => Convert.FromBase64String(src.Img_Base64))).ReverseMap();
            CreateMap<EditCourseCommand, Course>().ForMember(dest => dest.Course_Img, opt => opt.MapFrom(src => Convert.FromBase64String(src.Img_Base64))).ReverseMap();
            CreateMap<AddCourseSuggestionCommand, Course>().ReverseMap();
            CreateMap<EditCourseSuggestionCommand, Course>().ReverseMap();
            CreateMap<AddTraineeCommand, Trainer>().ForMember(dest => dest.Photograph, opt => opt.MapFrom(src => Convert.FromBase64String(src.Photograph_Base64))).ReverseMap();
            CreateMap<EditTraineeCommand, Trainer>().ForMember(dest => dest.Photograph, opt => opt.MapFrom(src => Convert.FromBase64String(src.Photograph_Base64))).ReverseMap();
            CreateMap<AddLecturerCommand, Lecturer>().ForMember(dest => dest.Photograph, opt => opt.MapFrom(src => Convert.FromBase64String(src.Photograph_Base64))).ReverseMap();
            CreateMap<EditLecturerCommand, Lecturer>().ForMember(dest => dest.Photograph, opt => opt.MapFrom(src => Convert.FromBase64String(src.Photograph_Base64))).ReverseMap();
            CreateMap<LecturerCertificateCommand, LecturerCertificate>().ForMember(dest => dest.LecturerCertificateImg, opt => opt.MapFrom(src => Convert.FromBase64String(src.LecturerCertificateImg_Base64))).ReverseMap();
        }
    }
}
