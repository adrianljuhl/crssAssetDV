using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using crssAssetDV.Models;
using AutoMapper;
using crssAssetDV.Dtos;
using System.Data.Entity;


namespace crssAssetDV.Api
{
    public class PeopleController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public PeopleController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/People
        public IHttpActionResult GetPeople(string query = null)
        {
            var peopleQuery = _context.Peoples;

            if (!String.IsNullOrWhiteSpace(query))
                peopleQuery = (DbSet<People>)peopleQuery.Where(c => c.MIS.Contains(query));

            var peopleDtos = peopleQuery
                .ToList()
                .Select(Mapper.Map<People, PeopleDto>);

            return Ok(peopleDtos);
        }


        //GET /api/People/1
        public IHttpActionResult GetPeople(int id)
        {
            var people = _context.Peoples.SingleOrDefault(c => c.Id == id);

            if (people == null)
                return NotFound();

            return Ok(Mapper.Map<People, PeopleDto>(people));
        }

        //POST /api/People
        [HttpPost]
        public IHttpActionResult CreatePeople(PeopleDto peopleDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var people = Mapper.Map<PeopleDto, People>(peopleDto);
                _context.Peoples.Add(people);
                _context.SaveChanges();

            peopleDto.Id = people.Id;
            return Created(new Uri(Request.RequestUri + "/" + people.Id), peopleDto);
        }

        //PUT /api/people/1
        public IHttpActionResult UpdatePeople(int id, PeopleDto peopleDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var peopleInDB = _context.Peoples.SingleOrDefault(c => c.Id == id);

            if (peopleInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(peopleDto, peopleInDB);

            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeletePeople(int id)
        {
            var peopleInDb = _context.Peoples.SingleOrDefault(c => c.Id == id);

            if (peopleInDb == null)
                return NotFound();

            _context.Peoples.Remove(peopleInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
