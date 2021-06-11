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
        public class LoanNotesController : ApiController
        {
            private ApplicationDbContext _context;

            public LoanNotesController()
            {
                _context = new ApplicationDbContext();
            }

            // GET: /api/LoanNotes
            public IHttpActionResult GetLoanNotes(string query = null)
            {
                var loanNotesQuery = _context.LoanNotes
                    .Include(c => c.Loan);
                    

                var loanNoteDtos = loanNotesQuery
                    .ToList()
                    .Select(Mapper.Map<LoanNote, LoanNoteDto>);

                return Ok(loanNoteDtos);
            }


            //GET /api/LoanNotes/1
            public IHttpActionResult GetLoan(int id)
            {
                var loanNote = _context.LoanNotes.SingleOrDefault(c => c.Id == id);

                if (loanNote == null)
                    return NotFound();

                return Ok(Mapper.Map<LoanNote, LoanNoteDto>(loanNote));
            }
            //POST /api/LoanNotes
            [HttpPost]
            public IHttpActionResult CreateLoanNote(LoanNoteDto loanNoteDto)
            {
                if (!ModelState.IsValid)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);


                var loanNote = Mapper.Map<LoanNoteDto, LoanNote>(loanNoteDto);
                    _context.LoanNotes.Add(loanNote);
                    _context.SaveChanges();

                loanNoteDto.Id = loanNote.Id;
                return Created(new Uri(Request.RequestUri + "/" + loanNote.Id), loanNoteDto);
            }

            //PUT /api/loanNotes/1
            public IHttpActionResult UpdateLoanNote(int id, LoanNoteDto loanNoteDto)
            {
                if (!ModelState.IsValid)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                var loanNoteInDB = _context.LoanNotes.SingleOrDefault(c => c.Id == id);

                if (loanNoteInDB == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                Mapper.Map(loanNoteDto, loanNoteInDB);

                _context.SaveChanges();
                return Ok();
            }

            // DELETE /api/loanNotes/1
            [HttpDelete]
            public IHttpActionResult DeleteLoan(int id)
            {
                var loanNoteInDb = _context.LoanNotes.SingleOrDefault(c => c.Id == id);

                if (loanNoteInDb == null)
                    return NotFound();

                _context.LoanNotes.Remove(loanNoteInDb);
                _context.SaveChanges();

                return Ok();
            }
        }    
}