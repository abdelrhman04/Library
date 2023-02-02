using AutoMapper;
using BLL.Services;
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
            
            CreateMap<Authors, AddAuthourCommands>().ReverseMap();
            CreateMap<Authors, UpdateAuthorCommands>().ReverseMap();
            //CreateMap<Authors, AuthorInput>().ReverseMap(); 
            CreateMap<AuthorOutput, Authors>().ReverseMap();
            
            CreateMap<Books, AddBooksCommand>().ReverseMap(); 
            CreateMap<Books, UpdateBooksCommand>().ReverseMap();
            //CreateMap<Books, BooksInput>().ReverseMap();
            CreateMap<BooksOutput, Books>().ReverseMap();
            CreateMap<PointOutput, Point>().ReverseMap();
            CreateMap<PointInput, Point>().ReverseMap();

           // CreateMap<Types, TypesInput>().ReverseMap();
            CreateMap<Types, UpdateTypesCommand>().ReverseMap();
            CreateMap<Types, AddTypesCommand>().ReverseMap();
            CreateMap<TypesOutput, Types>().ReverseMap(); 

           // CreateMap<IdentityRole, RolesInput>().ReverseMap();
            CreateMap<IdentityRole, AddRolesCommand>().ReverseMap();
            CreateMap<IdentityRole, UpdateRolesCommand>().ReverseMap();
            CreateMap<RolesOutput, IdentityRole>().ReverseMap();

            CreateMap<Students, UpdateStudentsCommand>().ReverseMap();
            CreateMap<Students, RegisterCommand>().ReverseMap();
            CreateMap<Students, StudentsInput>().ReverseMap();
            CreateMap<StudentsOutput, Students>().ReverseMap();
     
            CreateMap<Brorows, AddBrorowsCommand>().ReverseMap();
            CreateMap<Brorows, UpdateBrorowsCommand>().ReverseMap();
            //CreateMap<Brorows, BrorowsInput>().ReverseMap();
            CreateMap<BrorowsOutput, Brorows>().ReverseMap();
        }
    }
}
