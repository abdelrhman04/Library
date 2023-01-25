using AutoMapper;
using CORE.DAL;
using CORE.DTO;
using CORE.DTO.Authors;
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
        }
    }
}
