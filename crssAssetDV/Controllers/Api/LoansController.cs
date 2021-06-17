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
    public class LoansController : ApiController
    {
        private ApplicationDbContext _context;

        public LoansController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/Loans
        public IHttpActionResult GetLoans(string query = null)
        {
            var loansQuery = _context.Loans
                .Include(c => c.Device)
                .Include(c => c.LoanType)
                .Include(c => c.People);
                

            var loanDtos = loansQuery
                .ToList()
                .Select(Mapper.Map<Loan, LoanDto>);
            
            return Ok(loanDtos);
        }


        //GET /api/Loans/1
        public IHttpActionResult GetLoan(int id)
        {
            var loan = _context.Loans.SingleOrDefault(c => c.Id == id);

            if (loan == null)
                return NotFound();

            return Ok(Mapper.Map<Loan, LoanDto>(loan));
        }
        //POST /api/Loans
        [HttpPost]
        public IHttpActionResult CreateLoan(LoanDto loanDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            var loan = Mapper.Map<LoanDto, Loan>(loanDto);
            _context.Loans.Add(loan);
            _context.SaveChanges();

            loanDto.Id = loan.Id;
            return Created(new Uri(Request.RequestUri + "/" + loan.Id), loanDto);
        }

        //PUT /api/loans/1
        public IHttpActionResult UpdateLoan(int id, LoanDto loanDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var loanInDB = _context.Loans.SingleOrDefault(c => c.Id == id);

            if (loanInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(loanDto, loanInDB);

            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/loans/1
        [HttpDelete]
        public IHttpActionResult DeleteLoan(int id)
        {
            var loanInDb = _context.Loans.SingleOrDefault(c => c.Id == id);

            if (loanInDb == null)
                return NotFound();

            _context.Loans.Remove(loanInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
