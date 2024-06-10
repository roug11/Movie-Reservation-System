package com.example.theatre.persistence.repository;

import com.example.theatre.api.dto.TheatreRequestDto;
import com.example.theatre.persistence.entity.Theatre;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface TheatreRepository {
    Theatre getById(Long id);
    List<Theatre> getAll();
    void insert(Theatre theatre);
    Theatre update(Theatre theatre);
    void delete(Long id);
}
