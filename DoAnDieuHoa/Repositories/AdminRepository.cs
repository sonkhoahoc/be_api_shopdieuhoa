using DADH.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DADH.IRepositories;
using System.Data;

namespace DADH.Repositories
{
    internal class AdminRepository : IAdminRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public AdminRepository(ApplicationContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

    }
}
