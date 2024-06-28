/*     [Authorize(Policy = "OperationalRights")] */
/*     [HttpPut("{id}")] */
/*     public async Task<IActionResult> Update( */
/*         [FromBody] ConvenioUpdateDto request, */
/*         [FromRoute] Guid id) */
/*     { */
/*         var response = await service.Update(request, id); */
/*         var result = response.ToResultDto(); */
/*         if (response.IsFailed) */
/*             return BadRequest(result); */

/*         return Ok(result); */
/*     } */

/*     [Authorize(Policy = "OperationalRights")] */
/*     [HttpDelete("{id}")] */
/*     public IActionResult Delete( */
/*         [FromRoute] Guid id) */
/*     { */
/*         var response = service.Delete(id); */
/*         var result = response.ToResultDto(); */
/*         if (response.IsFailed) */
/*             return BadRequest(result); */

/*         return Ok(result); */
/*     } */
/* } */