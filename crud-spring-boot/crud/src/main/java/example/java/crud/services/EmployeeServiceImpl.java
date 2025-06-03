package example.java.crud.services;

import example.java.crud.dtos.EmployeeDto;
import example.java.crud.entities.Employee;
import example.java.crud.exceptions.ResourceNotFoundException;
import example.java.crud.mapper.EmployeeMapper;
import example.java.crud.repositories.EmployeeRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor(onConstructor_ = {@Autowired})
public class EmployeeServiceImpl implements EmployeeService {

    @Autowired
    private final EmployeeRepository employeeRepository;

    @Override
    public EmployeeDto create(EmployeeDto employeeDto) {
        Employee employee = EmployeeMapper.mapToEmployee(employeeDto);
        Employee savedEmployee = employeeRepository.save(employee);
        return EmployeeMapper.mapToEmployeeDto(savedEmployee);
    }

    @Override
    public EmployeeDto read(Long id) {
        Employee employee = employeeRepository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException("Employee not found with given id" + id));

        return EmployeeMapper.mapToEmployeeDto(employee);
    }

    @Override
    public List<EmployeeDto> readAll() {
        return employeeRepository.findAll().stream()
                .map(EmployeeMapper::mapToEmployeeDto)
                .collect(Collectors.toList());
    }

    @Override
    public EmployeeDto update(EmployeeDto employeeDto) {

        Employee foundEmployee = employeeRepository.findById(employeeDto.getId())
                .orElseThrow(() -> new ResourceNotFoundException("Employee with given id" + employeeDto.getId()));

        foundEmployee.setFirstName(employeeDto.getFirstName());
        foundEmployee.setLastName(employeeDto.getLastName());
        foundEmployee.setEmail(employeeDto.getEmail());

        Employee updatedEmployee = employeeRepository.save(foundEmployee);

        return EmployeeMapper.mapToEmployeeDto(updatedEmployee);
    }

    @Override
    public void delete(Long id) {
        Employee foundEmployee = employeeRepository.findById(id)
                .orElseThrow(() -> new ResourceNotFoundException("Employee with given id" + id));

        employeeRepository.delete(foundEmployee);
    }
}
