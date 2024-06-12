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

    @GetMapping
    public String sayHello() {
        return "Hello, World!";
    }

    @GetMapping("/theatre")
    public List<TheatreRequestDto> getTheatres(){
        return theatreService.getAll();
    }

    @GetMapping("/theatre/{theatreid}")
    public TheatreRequestDto getById(@PathVariable("theatreid") int theatreid){
        return theatreService.getTheatreById(theatreid);
    }

    @PostMapping("/theatre")
    public TheatreRequestDto create(@RequestBody TheatreRequestDto theatreRequestDto){
        return theatreService.addTheatre(theatreRequestDto);
    }

    @PutMapping("/theatre")
    public TheatreRequestDto update(@RequestBody int id, TheatreRequestDto theatreRequestDto){
        return theatreService.updateTheatre(id, theatreRequestDto);
    }

    @DeleteMapping("/theatre/{theatreid}")
    public void delete(@PathVariable("theatreid") int theatreid){
        theatreService.delete(theatreid);
    }
}
