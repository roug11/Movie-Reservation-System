package com.example.theatre.service;

import com.example.theatre.api.dto.TheatreDto;
import com.example.theatre.persistence.entity.Theatre;
import com.example.theatre.persistence.repository.TheatreRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.ArrayList;
import java.util.List;

@Service
@Transactional
public class TheatreService {
    private final TheatreRepository theatreRepository;

    @Autowired
    public TheatreService(TheatreRepository theatreRepository) {
        this.theatreRepository = theatreRepository;
    }

    public Theatre getTheatreById(Integer id){
        Theatre theatreEntity = theatreRepository.getById(id);
        return theatreEntity;
    }

    public List<Theatre> getAll(){
        List<Theatre> theatreList = theatreRepository.findAll();
        return theatreList;
    }

    public Theatre addTheatre(TheatreDto theatreDto){
        Theatre theatre = new Theatre();
        theatre = theatreDto.mapToEntity();
        theatreRepository.saveAndFlush(theatre);
        return theatre;
    }

    public Theatre updateTheatre(Integer id, TheatreDto theatreDto){
        Theatre theatre = new Theatre();
        theatre = theatreRepository.getById(id);
        theatre.setName(theatreDto.getName());
        theatre.setAddress(theatreDto.getAddress());

        return theatre;

    }

    public void delete(Integer id){
        theatreRepository.deleteById(id);
    }
}
