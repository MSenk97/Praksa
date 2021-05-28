import React, { Component } from 'react';
import { Button, FormGroup, Input, Label, Modal, ModalHeader, ModalBody, ModalFooter, Table } from 'reactstrap';
import axios from 'axios';

class App extends Component {
  studentApi = 'https://localhost:44337/api/student/';
  
  state = {
    students: [],
    newStudentData: {
      StudentID: '',
      Ime: '',
      FakultetID: ''
    },
    editStudentData: {
      Ime: '',
      FakultetID: ''
    },
    newStudentModal: false,
    editStudentModal: false,
    sortBy: 'Ime',
    sortOrder: 'ASC'
  }
  
  componentDidMount() {
    this._refreshStudents(this.state.sortBy, this.state.sortOrder);
  }
  
  toggleNewStudentModal() {
    this.setState({
      newStudentModal: !this.state.newStudentModal
    })
  }
  
  toggleEditStudentModal() {
    this.setState({
      editStudentModal: !this.state.editStudentModal
    })
  }
  
  _refreshStudents(sortBy, sortOrder) {
    axios.get(this.studentApi + '?SortBy=' + sortBy + '&SortOrder=' + sortOrder).then((response) => {
      this.setState({
        students: response.data
      })
    });
  }
  
  changeSortParams(sortBy) {
    let sortOrder = this.state.sortOrder;
    if (this.state.sortBy === sortBy) {
      sortOrder = this.toggleSortOrder(sortOrder);
    } else {
      this.setState({sortBy: sortBy});
    }
    this._refreshStudents(sortBy, sortOrder);
  }
  
  toggleSortOrder() {
    if (this.state.sortOrder==='ASC') {
      this.setState({sortOrder: 'DESC'});
      return 'DESC';
    } else {
      this.setState({sortOrder: 'ASC'});
      return 'ASC';
    }
  }
  
  addStudent() {
    axios.post(this.studentApi, this.state.newStudentData).then((response) => {
      this._refreshStudents(this.state.sortBy, this.state.sortOrder);
      this.setState({
        newStudentModal: false,
        newStudentData: {
          Ime: '',
          FakultetID: ''
        }
      });
    });
  }
  
  updateStudent() {
    let { Ime, FakultetID } = this.state.editStudentData;
    axios.put(this.studentApi + this.state.editStudentData.StudentId, {
      Ime, FakultetID
    }).then((response) => {
      this._refreshStudents(this.state.sortBy, this.state.sortOrder);
    })
    this.setState({
      editStudentModal: false, editStudentData: { StudentId: '', Ime: '', FakultetID: '' }
    })
  }
  
  editStudent(id, ime, fakultetID) {
    this.setState({
      editStudentData: {
        StudentID: id,
        Ime: ime,
        FakultetID: fakultetID
      },
      editStudentModal: ! this.editStudentModal
    });
  }
  
  deleteStudent(id) {
    axios.delete(this.studentApi + id).then((response) => {
      this._refreshStudents(this.state.sortBy, this.state.sortOrder);
    });
  }
  
  render(){
    let students = this.state.students.map((student) => {
      return (
        <tr key={student.StudentID}>
          <td>{student.Ime}</td>
          <td>{student.FakultetID}</td>
          <td>
            <Button color="success" size="sm" onClick={this.editStudent.bind(this, student.StudentId, student.Ime, student.FakultetID)}>Edit</Button>
            <Button className="mx-2" color="danger" size="sm" onClick={this.deleteStudent.bind(this, student.StudentId)}>Delete</Button>
          </td>
        </tr>
      )
    });
    
    return (
      <div className="App container">
        
        <h1 className="my-3">Students App</h1>
        
        <Button className="my-3" color="primary" onClick={this.toggleNewStudentModal.bind(this)}>New student</Button>
        
        <Modal isOpen={this.state.newStudentModal} toggle={this.toggleNewStudentModal.bind(this)}>
          <ModalHeader toggle={this.toggleNewStudentModal.bind(this)}>Add a new student</ModalHeader>
          
          <ModalBody>
            <FormGroup>
              <Label for="ime">Ime</Label>
              <Input id="ime" value={this.state.newStudentData.Ime} onChange={(e) => {
                let { newStudentData } = this.state;
                newStudentData.Ime = e.target.value;
                this.setState({ newStudentData });
              }} />
            </FormGroup>
            
            <FormGroup>
              <Label for="fakultetID">FakultetID</Label>
              <Input id="fakultetID" value={this.state.newStudentData.FakultetID} onChange={(e) => {
                let { newStudentData } = this.state;
                newStudentData.FakultetID = e.target.value;
                this.setState({ newStudentData });
              }} />
            </FormGroup>
          </ModalBody>
          
          <ModalFooter>
            <Button color="primary" onClick={this.addStudent.bind(this)}>Add</Button>{' '}
            <Button color="secondary" onClick={this.toggleNewStudentModal.bind(this)}>Cancel</Button>
          </ModalFooter>
        </Modal>
        
        <Modal isOpen={this.state.editStudentModal} toggle={this.toggleEditStudentModal.bind(this)}>
          <ModalHeader toggle={this.toggleEditStudentModal.bind(this)}>Edit student data</ModalHeader>
          
          <ModalBody>
            <FormGroup>
              <Label for="ime">Ime</Label>
              <Input id="ime" value={this.state.editStudentData.Ime} onChange={(e) => {
                let { editStudentData } = this.state;
                editStudentData.Ime = e.target.value;
                this.setState({ editStudentData });
              }} />
            </FormGroup>
            
            
            <FormGroup>
              <Label for="fakultetID">FakultetID</Label>
              <Input id="fakultetID" value={this.state.editStudentData.FakultetID} onChange={(e) => {
                let { editStudentData } = this.state;
                editStudentData.FakultetID = e.target.value;
                this.setState({ editStudentData });
              }} />
            </FormGroup>
          </ModalBody>
          
          <ModalFooter>
            <Button color="primary" onClick={this.updateStudent.bind(this)}>Confirm</Button>{' '}
            <Button color="secondary" onClick={this.toggleEditStudentModal.bind(this)}>Cancel</Button>
          </ModalFooter>
        </Modal>
        
        <Table>
          <thead>
            <tr>
              <th>
                <div>
                  Ime
                  <Button className="mx-1" color="white" size="sm" onClick={this.changeSortParams.bind(this, 'Ime')}>Sort</Button>
                </div>
              </th>

              <th>
                <div>
                  FakultetID
                  <Button className="mx-1" color="white" size="sm" onClick={this.changeSortParams.bind(this, 'FakultetID')}>Sort</Button>
                </div>
              </th>
              <th>Actions</th>
            </tr>  
          </thead>
          
          <tbody>
            {students}
          </tbody>
        </Table>
      </div>
    );
  }
}

export default App;