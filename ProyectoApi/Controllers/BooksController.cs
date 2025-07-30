using FastMapper;
using ProyectoApi.Data;
using ProyectoApi.Data.Model;
using ProyectoApi.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoApi.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        ApiContext db = new ApiContext();

        //GET:
        [HttpGet]
        [Route("getAll")]
        public IEnumerable<Book> Get()
        {
            return db.Books.ToList();
        }

        //Get: 
        [HttpGet]
        [Route("getItem/{id}")]
        public Book Get([FromUri] int id)
        {
            return db.Books.Find(id);
        }

        //POST
        [HttpPost]
        [Route("Create")]
        public int Post([FromBody] BookDTO request)
        {
            var book = TypeAdapter.Adapt<Book>(request);
            db.Books.Add(book);
            db.SaveChanges();

            return book.Id;
        }

        // PUT: api/Books/5
        [HttpPut]
        [Route("update")]
        public int Put([FromBody] BookDTO request)
        {
            if (request == null && request.Id == 0)
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.MethodNotAllowed)
                    {
                        Content = new StringContent(string.Format("El Identificador no deb ser nulo")),
                        ReasonPhrase = "Identificador requerido"
                    });
            }
            Book currentBook = db.Books.Find(request.Id);
            if (currentBook == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No se encontró el libro con Identificador = {0}", request.Id)),
                    ReasonPhrase = "Identificador del libro no encontrado"
                };
                throw new HttpResponseException(resp);
            }

            var bookCopy = TypeAdapter.Adapt<Book>(request);
            TypeAdapter.Adapt(bookCopy, currentBook);
            db.Books.AddOrUpdate(currentBook);
            db.SaveChanges();
            return currentBook.Id;
        }
    }
}
