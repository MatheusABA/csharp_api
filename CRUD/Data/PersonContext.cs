﻿using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Data;

public class PersonContext(DbContextOptions<PersonContext> options) : DbContext(options)
{
    public DbSet<Person> Person { get; set; }
    
}