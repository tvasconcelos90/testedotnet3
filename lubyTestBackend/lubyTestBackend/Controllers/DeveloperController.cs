﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using lubyTestBackend.Domain;
using lubyTestBackend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lubyTestBackend.Controllers
{
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperController(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        [HttpGet("api/[controller]")]
        public IActionResult GetAll()
        {
            try
            {
                var data = _developerRepository.GetAll();
                return Ok(data);
            } 
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("api/[controller]/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _developerRepository.GetById(id);
                if (data == null)
                    return NotFound();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPost("api/[controller]/insert")]
        public IActionResult Insert([FromBody]DeveloperDomain developer)
        {
            try
            {
                var data = _developerRepository.Insert(developer);
                return Ok();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPost("api/[controller]/delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _developerRepository.Delete(id);
                if (data == 0)
                    return NotFound();
                return Ok();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }


        [HttpPut("api/[controller]")]
        public IActionResult Update([FromBody] DeveloperDomain developer)
        {
            try
            {
                var data = _developerRepository.Update(developer);
                if (data == 0)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
