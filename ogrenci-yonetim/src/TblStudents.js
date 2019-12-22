import React, { Component } from "react";
import {
  Table,
  Modal,
  Form,
  Input,
  Checkbox,
  Row,
  Col,
  Select,
  Radio
} from "antd";
import { Button } from "reactstrap";
import "antd/dist/antd.css";
import Axios from "axios";
const { Column } = Table;

//Begin: Modal-Form Section for Create
const CollectionCreateForm = Form.create({ name: "form_in_modal" })(
  class extends React.Component {
    render() {
      const { visible, onCancel, onCreate, form } = this.props;
      const { getFieldDecorator } = form;
      const { Option } = Select;
      const prefixSelector = getFieldDecorator("prefix", {
        initialValue: "90"
      })(
        <Select style={{ width: 70 }}>
          <Option value="90">+90</Option>
          <Option value="87">+87</Option>
        </Select>
      );

      return (
        <Modal
          visible={visible}
          title="Yeni Öğrenci Oluştur"
          okText="Oluştur"
          cancelText="İptal"
          onCancel={onCancel}
          onOk={onCreate}
        >
          <Form layout="vertical">
            <Form.Item label="Adı">
              {getFieldDecorator("ad", {
                rules: [{ required: true, message: "Lüfen adını girin!" }]
              })(<Input />)}
            </Form.Item>

            <Form.Item label="Soyadı">
              {getFieldDecorator("soyad", {
                rules: [{ required: true, message: "Lüfen soyadını girin!" }]
              })(<Input />)}
            </Form.Item>

            <Form.Item label="E-mail">
              {getFieldDecorator("eposta", {
                rules: [
                  {
                    type: "email",
                    message: "The input is not valid E-mail!"
                  }
                  // ,
                  // {
                  //   required: true,
                  //   message: "Please input your E-mail!"
                  // }
                ]
              })(<Input />)}
            </Form.Item>

            <Form.Item label="Phone Number">
              {getFieldDecorator("gsm", {
                rules: [
                  { required: true, message: "Please input your phone number!" }
                ]
              })(
                <Input addonBefore={prefixSelector} style={{ width: "100%" }} />
              )}
            </Form.Item>

            <Form.Item label="Durum" >
              {getFieldDecorator("durum")(
                <Radio.Group>
                  <Radio value="True">Aktif</Radio>
                  <Radio value="False">Pasif</Radio>
                </Radio.Group>
              )}
            </Form.Item>
          </Form>
        </Modal>
      );
    }
  }
);
//End: Modal-Form Section for Create

// Begin: Modal-Form Section for Modified
const CollectionModifiedForm = Form.create({ name: "form_in_modal" })(
  class extends React.Component {
    render() {
      const { visible, onCancel, onCreate, form } = this.props;
      const { getFieldDecorator } = form;
      const { Option } = Select;
      const prefixSelector = getFieldDecorator("prefix", {
        initialValue: "90"
      })(
        <Select style={{ width: 70 }}>
          <Option value="90">+90</Option>
          <Option value="87">+87</Option>
        </Select>
      );

      return (
        <Modal
          visible={visible}
          title="Yeni Öğrenci Oluştur"
          okText="Oluştur"
          cancelText="İptal"
          onCancel={onCancel}
          onOk={onCreate}
        >
          <Form layout="vertical">
            <Form.Item label="Adı">
              {getFieldDecorator("ad", {
                rules: [{ required: true, message: "Lüfen adını girin!" }]
              })(<Input />)}
            </Form.Item>

            <Form.Item label="Soyadı">
              {getFieldDecorator("soyad", {
                rules: [{ required: true, message: "Lüfen soyadını girin!" }]
              })(<Input />)}
            </Form.Item>

            <Form.Item label="E-mail">
              {getFieldDecorator("eposta", {
                rules: [
                  {
                    type: "email",
                    message: "The input is not valid E-mail!"
                  }
                  // ,
                  // {
                  //   required: true,
                  //   message: "Please input your E-mail!"
                  // }
                ]
              })(<Input />)}
            </Form.Item>

            <Form.Item label="Phone Number">
              {getFieldDecorator("gsm", {
                rules: [
                  { required: true, message: "Please input your phone number!" }
                ]
              })(
                <Input addonBefore={prefixSelector} style={{ width: "100%" }} />
              )}
            </Form.Item>

            <Form.Item label="Durum">
              {getFieldDecorator("durum")(
                <Radio.Group>
                  <Radio disabled value="True">Aktif</Radio>
                  <Radio disabled value="False">Pasif</Radio>
                </Radio.Group>
              )}
            </Form.Item>
          </Form>
        </Modal>
      );
    }
  }
);
//End: Modal-Form Section for Modified

export default class TblStudents extends Component {
  state = {
    visibleCreate: false,
    visibleModified: false,
    selectedStudentsId: -1,
    students: []
  };

  //Begin: Axios-GetStudents
  componentDidMount() {
    Axios.get("https://localhost:44382/api/Ogrenci").then(res => {
      // console.log(res);
      this.setState({ students: res.data.entities });
      // console.log(this.state.Students);
    });
  }
  //End: Axios-GetStudents

  //Begin: Modal-Form Section

  // Begin: Axios-ModifiedStudent

  showModalModified = prmStudent => {
    const { form } = this.formRefModified.props;
    form.validateFields((err, values) => {
    //  console.log(prmStudent);
    
    });
    // console.log(prmStudentId);
    this.setState({
      selectedStudentsId: prmStudent.id,
      visibleModified: true
    });
  };

  handleCancelModified = () => {
    this.setState({ visibleModified: false, selectedStudentsId: -1 });
  };

  handleModified = () => {
    const { form } = this.formRefModified.props;
    form.validateFields((err, values) => {
      if (err) {
        return;
      }
      // console.log("Received values of form: ", values);
      //değerler "values" içinde
      try {
        Axios.put(
          "https://localhost:44382/api/Ogrenci/" +
            this.state.selectedStudentsId,
          values
        )
          .then(response => {
            this.componentDidMount();
            this.successMessage("İşem başarılı");
            // console.log(response);
          })
          .catch(error => {
            // console.log(error.response.status);
            this.errorMessage(
              "İşem başarısız. Lütfen daha sonra tekrar deneyiniz."
            );
          });
      } catch (error) {
        this.errorMessage("Lütfen geliştiriciler ile bağlı kurun.", "error");
      }
      form.resetFields();
      this.setState({ visibleModified: false, selectedStudentsId: -1 });
    });
  };

  modifiedFormRef = formRefModified => {
    this.formRefModified = formRefModified;
  };
  // End: Axios-ModifiedStudent

  //Begin: Axios-RegisterStudent

  showModalCreate = () => {
   
    this.setState({ visibleCreate: true });
  };

  handleCancelCreate = () => {
    this.setState({ visibleCreate: false });
  };

  handleCreate = () => {
    const { form } = this.formRefCreate.props;
    form.validateFields((err, values) => {
      if (err) {
        return;
      }
      //formdan gelen değerler "values" içinde
      try {
        console.log(values);
        Axios.post("https://localhost:44382/api/Ogrenci", values)
          .then(response => {
            this.componentDidMount();
            this.successMessage("İşem başarılı");
            // console.log(response);
          })
          .catch(error => {
            // console.log(error.response.status);
            this.errorMessage(
              "İşem başarısız. Lütfen daha sonra tekrar deneyiniz."
            );
          });
      } catch (error) {
        this.errorMessage("Lütfen geliştiriciler ile bağlı kurun.", "error");
      }
      // console.log("Received values of form: ", values);
      form.resetFields();
      this.setState({ visibleCreate: false });
    });
  };
  //End Axios-RegisterStudent

  saveFormRefCreate = formRefCreate => {
    this.formRefCreate = formRefCreate;
  };
  //End Modal-Form Section

  //Begin:  Modal Message
  successMessage = prmMessage => {
    Modal.success({
      content: prmMessage
    });
  };
  errorMessage = prmMessage => {
    Modal.success({
      content: prmMessage
    });
  };
  warnMessage = prmMessage => {
    Modal.success({
      content: prmMessage
    });
  };
  //End:  Modal Message

  //Begin: State Update

  //End: State Update
 
  render() {
    this.state.students.map(prm=>prm.durum===false? prm.durum="Pasif":prm.durum="Aktif" )
    return (
      <div>
        <Table dataSource={this.state.students} rowKey="id">
          {/* {console.log(this.state.lessons)} */}
          <Column
            title="Id"
            dataIndex="id"
            // key="createdDate"
          />
          < Column title="Numara" dataIndex="no" />
          <Column title="Adı" dataIndex="ad" />
         < Column title="Soyadı" dataIndex="soyad" />
         < Column title="Telefon" dataIndex="gsm" />
         < Column title="E-mail" dataIndex="eposta" />
         < Column title="Durum" dataIndex="durum"  />
          <Column
            title="Güncellenme Zamanı"
            dataIndex="createdDate"
            // key="createdDate"
          />
          <Column
            title="Oluşturulma Zamanı"
            dataIndex="modifiedDate"
            // key="modifiedDate"
          />
          <Column
            title="Aksiyonlar"
            // key="action"

            render={(text, record) => (
              <span>
                {/* {console.log("record", record)} */}
                {/* <a>Invite {record.lastName}</a>
                <Divider type="vertical" /> */}
                <Button
                  color="warning"
                  onClick={e => {
                    // console.log(record)
                    this.showModalModified(record);
                  }}
                >
                  Düzenle
                </Button>
                {/* <Button
                  onClick={e => {
                    this.onDelete(record.id);
                  }}
                  color="danger"
                >
                  Sil
                </Button> */}
              </span>
            )}
          />
        </Table>
        <Button color="success" onClick={this.showModalCreate}>
          Yeni Öğrenci
        </Button>
        {/* Begin: Modal-Form Component for Create */}
        <CollectionCreateForm
          wrappedComponentRef={this.saveFormRefCreate}
          visible={this.state.visibleCreate}
          onCancel={this.handleCancelCreate}
          onCreate={this.handleCreate}
        />
        {/* End: Modal-Form Component for Create */}

        {/* Begin: Modal-Form Component for Modified */}
        <CollectionModifiedForm
          wrappedComponentRef={this.modifiedFormRef}
          visible={this.state.visibleModified}
          onCancel={this.handleCancelModified}
          onConfirm={this.handleModified}
        />
        {/* End: Modal-Form Component for Modified */}
      </div>
    );
  }
}

// Great using axios example
// axios.get('http://jsonplaceholder.typicode.com/todos')
// .then(function (response) {
//   resultElement.innerHTML = generateSuccessHTMLOutput(response);
// })
// .catch(function (error) {
//   resultElement.innerHTML = generateErrorHTMLOutput(error);
// });
