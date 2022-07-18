using BlogAPI.Models;
using EF.Core.Repository.Interface.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlogAPI.Repository
{
    public interface IBlogRepository<Blog>
    {
        IEnumerable<BlogDto> GetAll();
        Blog Get(long? id);
        Blog Create(BlogDto blogDto);
        int Update(long id, BlogDto blogDto);
        int Delete(long id);
    }
}
