using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkfnyServices.MediatR.TrainerEntity.Commands
{
    public class DeleteLecturerCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
