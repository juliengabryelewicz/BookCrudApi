using BookCrudApi.Entities;
using BookCrudApi.Dto.Books;

public interface IBookService
{
    IEnumerable<Book> GetAll();
    Book GetById(int id);
    void Create(CreateRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}
