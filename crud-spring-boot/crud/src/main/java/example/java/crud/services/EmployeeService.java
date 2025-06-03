package example.java.crud.services;

import example.java.crud.dtos.EmployeeDto;

import java.util.List;

public interface EmployeeService {
    EmployeeDto create(EmployeeDto employeeDto);
    EmployeeDto read(Long id);
    List<EmployeeDto> readAll();
    EmployeeDto update(EmployeeDto employeeDto);
    void delete(Long id);
}
