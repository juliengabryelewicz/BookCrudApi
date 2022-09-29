namespace BookCrudApi.Dto.Books;

using System.ComponentModel.DataAnnotations;
using BookCrudApi.Entities;

public class UpdateRequest
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Isbn { get; set; }
    
}