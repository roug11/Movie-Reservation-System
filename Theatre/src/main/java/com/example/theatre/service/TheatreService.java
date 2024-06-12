package com.example.theatre.service;

import com.example.theatre.api.dto.TheatreRequestDto;
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

    public TheatreRequestDto getTheatreById(Integer id){
        Theatre theatreEntity = theatreRepository.getById(id);
        return TheatreRequestDto.builder()
                .name(theatreEntity.getName())
                .address(theatreEntity.getAddress()).build();
    }

    public List<TheatreRequestDto> getAll(){
        List<Theatre> theatreList = theatreRepository.findAll();
        List<TheatreRequestDto> theatreRequestDtoList = new ArrayList<>();
        for (int i = 0; i < theatreList.size(); i++){
            TheatreRequestDto currentTheatre = new TheatreRequestDto(); /// აქ მგონი არ უნდა new-თი შექმნა
            currentTheatre = TheatreRequestDto.builder()
                    .name(theatreList.get(i).getName())
                    .address(theatreList.get(i).getAddress()).build();
            theatreRequestDtoList.add(currentTheatre);
        }
        return theatreRequestDtoList;
    }

    public TheatreRequestDto addTheatre(TheatreRequestDto theatreRequestDto){
        Theatre theatreEntity = new Theatre();
        theatreEntity = theatreRequestDto.mapToEntity();
        theatreRepository.saveAndFlush(theatreEntity);
        return theatreRequestDto;
    }

    public TheatreRequestDto updateTheatre(Integer id, TheatreRequestDto theatreRequestDto){
        Theatre theatreEntity = new Theatre();
        theatreEntity = theatreRepository.getById(id);
        theatreEntity.setName(theatreRequestDto.getName());
        theatreEntity.setAddress(theatreRequestDto.getAddress());


        return TheatreRequestDto.builder()
                .name(theatreEntity.getName())
                .address(theatreEntity.getAddress()).build();

    }

    public void delete(Integer id){
        theatreRepository.deleteById(id);
    }
}
