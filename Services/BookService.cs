namespace BookCrudApi.Services;

using AutoMapper;
using BookCrudApi.Entities;
using BookCrudApi.Contexts;
using BookCrudApi.Helpers;
using BookCrudApi.Dto.Books;

public class BookService : IBookService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public BookService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Book> GetAll()
    {
        return _context.Books;
    }

    public Book GetById(int id)
    {
        return getBook(id);
    }

    public void Create(CreateRequest model)
    {
        // validate
        if (_context.Books.Any(x => x.Isbn == model.Isbn))
            throw new AppException("Book with isbn '" + model.Isbn + "' already exists");

        var book = _mapper.Map<Book>(model);
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateRequest model)
    {
        var book = getBook(id);

        if (_context.Books.Any(x => x.Isbn == model.Isbn))
            throw new AppException("Book with Isbn '" + model.Isbn + "' already exists");

        _mapper.Map(model, book);
        _context.Books.Update(book);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var book = getBook(id);
        _context.Books.Remove(book);
        _context.SaveChanges();
    }

    private Book getBook(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null) throw new KeyNotFoundException("Book not found");
        return book;
    }
}