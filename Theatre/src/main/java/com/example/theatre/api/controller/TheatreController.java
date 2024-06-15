package com.example.theatre.api.controller;

import com.example.theatre.api.dto.TheatreRequestDto;
import com.example.theatre.persistence.entity.Theatre;
import com.example.theatre.service.TheatreService;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

@RestController
@RequiredArgsConstructor
public class TheatreController {
    private final TheatreService theatreService;

    @GetMapping("/theatre")
    public List<TheatreRequestDto> getTheatres(){
        List<Theatre> theatreList = theatreService.getAll();
        List<TheatreRequestDto> theatreDtoList =  theatreList.stream()
                .map(theatre -> TheatreRequestDto.builder()
                        .name(theatre.getName())
                        .address(theatre.getAddress())
                        .build())
                .collect(Collectors.toList());
        return theatreDtoList;
    }

    @GetMapping("/theatre/{theatreId}")
    public TheatreRequestDto getById(@PathVariable("theatreId") int theatreId){
        Theatre theatre = theatreService.getTheatreById(theatreId);
        TheatreRequestDto theatreDto = TheatreRequestDto.builder()
                                            .name(theatre.getName())
                                            .address(theatre.getAddress()).build();
        return theatreDto;
    }

    @PostMapping("/theatre")
    public TheatreRequestDto create(@RequestBody TheatreRequestDto theatreRequestDto){
        theatreService.addTheatre(theatreRequestDto);
        return theatreRequestDto;
    }

    @PutMapping("/theatre")
    public TheatreRequestDto update(@RequestBody int theatreId, TheatreRequestDto theatreRequestDto){
        Theatre theatre = theatreService.updateTheatre(theatreId, theatreRequestDto);
        TheatreRequestDto theatreDto = TheatreRequestDto.builder()
                .name(theatre.getName())
                .address(theatre.getAddress()).build();
        return theatreDto;
    }

    @DeleteMapping("/theatre/{theatreId}")
    public void delete(@PathVariable("theatreId") int theatreId){
        theatreService.delete(theatreId);
    }
}
