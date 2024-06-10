package com.example.theatre.persistence.repository;

import com.example.theatre.api.dto.TheatreRequestDto;
import com.example.theatre.persistence.entity.Theatre;

import javax.sql.DataSource;
import java.util.List;

public class TheatreRepositoryPostgreSQL implements TheatreRepository{
    private final DataSource dataSource;

    public TheatreRepositoryPostgreSQL(DataSource dataSource) {
        this.dataSource = dataSource;
    }

    @Override
    public Theatre getById(Long id) {
        return null;
    }

    @Override
    public List<Theatre> getAll() {
        return List.of();
    }

    @Override
    public void insert(Theatre theatre) {

    }

    @Override
    public Theatre update(Theatre theatre) {
        return null;
    }

    @Override
    public void delete(Long id) {

    }
}
