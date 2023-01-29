using AutoMapper;
using CORE.DAL;
using CORE.DTO;
using CORE.DTO.Authors;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Authors, AuthorInput>().ReverseMap(); 
            CreateMap<AuthorOutput, Authors>().ReverseMap(); 

            CreateMap<Books, BooksInput>().ReverseMap();
            CreateMap<BooksOutput, Books>().ReverseMap(); 

            CreateMap<Types, TypesInput>().ReverseMap();
            CreateMap<TypesOutput, Types>().ReverseMap(); 

            CreateMap<IdentityRole, RolesInput>().ReverseMap();
            CreateMap<RolesOutput, IdentityRole>().ReverseMap();

            CreateMap<Students, StudentsInput>().ReverseMap();
            CreateMap<StudentsOutput, Students>().ReverseMap();

            CreateMap<Brorows, BrorowsInput>().ReverseMap();
            CreateMap<BrorowsOutput, Brorows>().ReverseMap();
        }
    }
}
