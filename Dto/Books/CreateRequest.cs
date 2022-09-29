namespace BookCrudApi.Dto.Books;

using System.ComponentModel.DataAnnotations;

public class CreateRequest
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public string Isbn { get; set; }

}