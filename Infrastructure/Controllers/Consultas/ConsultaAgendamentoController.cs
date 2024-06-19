/*     /1* [HttpPut("{id}")] *1/ */
/*     /1* [Authorize(Policy = PoliciesConsts.Operational)] *1/ */
/*     /1* public async Task<IActionResult> Update( *1/ */
/*     /1*     [FromRoute] Guid id, *1/ */
/*     /1*     [FromForm] AgendamentoUpdateDto request) *1/ */
/*     /1* { *1/ */
/*     /1*     var response = await _service.Handler(request, id); *1/ */
/*     /1*     return Ok(response); *1/ */
/*     /1* } *1/ */
/* } */