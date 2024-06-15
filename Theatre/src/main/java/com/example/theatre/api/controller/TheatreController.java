package com.example.theatre.api.controller;

import com.example.theatre.api.dto.TheatreRequestDto;
import com.example.theatre.service.TheatreService;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequiredArgsConstructor
public class TheatreController {
    private final TheatreService theatreService;

    @GetMapping("/theatre")
    public List<TheatreRequestDto> getTheatres(){
        return theatreService.getAll();
    }

    @GetMapping("/theatre/{theatreId}")
    public TheatreRequestDto getById(@PathVariable("theatreId") int theatreId){
        return theatreService.getTheatreById(theatreId);
    }

    @PostMapping("/theatre")
    public TheatreRequestDto create(@RequestBody TheatreRequestDto theatreRequestDto){
        return theatreService.addTheatre(theatreRequestDto);
    }

    @PutMapping("/theatre")
    public TheatreRequestDto update(@RequestBody int theatreId, TheatreRequestDto theatreRequestDto){
        return theatreService.updateTheatre(theatreId, theatreRequestDto);
    }

    @DeleteMapping("/theatre/{theatreId}")
    public void delete(@PathVariable("theatreId") int theatreId){
        theatreService.delete(theatreId);
    }
}
