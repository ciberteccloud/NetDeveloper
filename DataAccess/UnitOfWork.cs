using DataAccess.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChinookContext _context;

        public UnitOfWork(ChinookContext context)
        {
            _context = context;
            Artists = new ArtistRepository(_context);
            Albums = new Repository<Album>(_context);
            Customers = new Repository<Customer>(_context);
            Employees = new Repository<Employee>(_context);
            Genres = new Repository<Genre>(_context);
            Invoices = new Repository<Invoice>(_context);
            InvoiceLines = new Repository<InvoiceLine>(_context);
            MediaTypes = new Repository<MediaType>(_context);
            Playlists = new Repository<Playlist>(_context);
            Tracks = new Repository<Track>(_context);
        }

        public IArtistRepository Artists { get; private set; }
        public Repository<Album> Albums { get; private set; }
        public Repository<Customer> Customers { get; private set; }
        public Repository<Employee> Employees { get; private set; }
        public Repository<Genre> Genres { get; private set; }
        public Repository<Invoice> Invoices { get; private set; }
        public Repository<InvoiceLine> InvoiceLines { get; private set; }
        public Repository<MediaType> MediaTypes { get; private set; }
        public Repository<Playlist> Playlists { get; private set; }
        public Repository<Track> Tracks { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
