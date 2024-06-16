package com.example.theatre.api.controller;

import com.example.theatre.api.dto.TheatreDto;
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
    public List<TheatreDto> getTheatres(){
        List<Theatre> theatreList = theatreService.getAll();
        List<TheatreDto> theatreDtoList =  theatreList.stream()
                .map(theatre -> TheatreDto.builder()
                        .name(theatre.getName())
                        .address(theatre.getAddress())
                        .build())
                .collect(Collectors.toList());
        return theatreDtoList;
    }

    @GetMapping("/theatre/{theatreId}")
    public TheatreDto getById(@PathVariable("theatreId") int theatreId){
        Theatre theatre = theatreService.getTheatreById(theatreId);
        TheatreDto theatreDto = TheatreDto.builder()
                                            .name(theatre.getName())
                                            .address(theatre.getAddress()).build();
        return theatreDto;
    }

    @PostMapping("/theatre")
    public TheatreDto create(@RequestBody TheatreDto theatreDto){
        theatreService.addTheatre(theatreDto);
        return theatreDto;
    }

    @PutMapping("/theatre")
    public TheatreDto update(@RequestBody int theatreId, TheatreDto theatreDto){
        Theatre theatre = theatreService.updateTheatre(theatreId, theatreDto);
        TheatreDto resultTheatreDto = TheatreDto.builder()
                .name(theatre.getName())
                .address(theatre.getAddress()).build();
        return resultTheatreDto;
    }

    @DeleteMapping("/theatre/{theatreId}")
    public void delete(@PathVariable("theatreId") int theatreId){
        theatreService.delete(theatreId);
    }
}
