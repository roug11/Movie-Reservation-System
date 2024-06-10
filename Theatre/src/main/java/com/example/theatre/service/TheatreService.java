package com.example.theatre.service;

import com.example.theatre.api.dto.TheatreRequestDto;
import com.example.theatre.persistence.entity.Theatre;
import com.example.theatre.persistence.repository.TheatreRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class TheatreService {
    private final TheatreRepository theatreRepository;

    @Autowired
    public TheatreService(TheatreRepository theatreRepository) {
        this.theatreRepository = theatreRepository;
    }

    public TheatreRequestDto getTheatreById(Long id){
        Theatre theatreEntity = theatreRepository.getById(id);
        return TheatreRequestDto.builder()
                .name(theatreEntity.getName())
                .address(theatreEntity.getAddress()).build();
    }

    public List<TheatreRequestDto> getAll(){
        List<Theatre> theatreList = theatreRepository.getAll();
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

    TheatreRequestDto addTheatre(TheatreRequestDto theatreRequestDto){
        Theatre theatreEntity = new Theatre();
        theatreEntity = theatreRequestDto.mapToEntity();
        theatreRepository.insert(theatreEntity);
        return theatreRequestDto;
    }

    TheatreRequestDto updateTheatre(Long id, TheatreRequestDto theatreRequestDto){
        Theatre theatreEntity = new Theatre();
        theatreEntity = theatreRepository.getById(id);
        theatreEntity.setName(theatreRequestDto.getName());
        theatreEntity.setAddress(theatreRequestDto.getAddress());
        theatreEntity = theatreRepository.update(theatreEntity);

        return TheatreRequestDto.builder()
                .name(theatreEntity.getName())
                .address(theatreEntity.getAddress()).build();

    }

    void delete(Long id){
        theatreRepository.delete(id);
    }
}
