import React, { Component } from "react";
import { Table, Modal, Form, Input, Checkbox, Row, Col } from "antd";
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
      return (
        <Modal
          visible={visible}
          title="Yeni Ders Oluştur"
          okText="Oluştur"
          cancelText="İptal"
          onCancel={onCancel}
          onOk={onCreate}
        >
          <Form layout="vertical">
            <Form.Item label="Ders Adı">
              {getFieldDecorator("ad", {
                rules: [{ required: true, message: "Lüfen ders adını girin!" }]
              })(<Input />)}
            </Form.Item>
            <Form.Item label="Derslikler">
              {getFieldDecorator("derslikler", {
                initialValue: ["1101", "1103"],
                rules: [{ required: true, message: "Lüfen derslik seçin!" }]
              })(
                <Checkbox.Group style={{ width: "100%" }}>
                  <Row>
                    <Col span={8}>
                      <Checkbox value="1101">1101</Checkbox>
                    </Col>
                    <Col span={8}>
                      <Checkbox disabled value="1102">
                        1102
                      </Checkbox>
                    </Col>
                    <Col span={8}>
                      <Checkbox value="1103">1103</Checkbox>
                    </Col>
                    <Col span={8}>
                      <Checkbox value="1104">1104</Checkbox>
                    </Col>
                    <Col span={8}>
                      <Checkbox value="Laboratuar-1">Laboratuar-1</Checkbox>
                    </Col>
                  </Row>
                </Checkbox.Group>
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
      const { visible, onCancel, onConfirm, form } = this.props;
      const { getFieldDecorator } = form;
      return (
        <Modal
          visible={visible}
          title="Düzenle"
          okText="Onayla"
          cancelText="İptal"
          onCancel={onCancel}
          onOk={onConfirm}
        >
          <Form layout="vertical">
            {/* <Form.Item label="id">
              {getFieldDecorator("id")(<Input  />)}
            </Form.Item> */}
            <Form.Item label="Yeni Ders Adı">
              {getFieldDecorator("ad", {
                rules: [{ required: true, message: "Lüfen ders adını girin!" }]
              })(<Input />)}
            </Form.Item>
            <Form.Item label="Derslikler">
              {getFieldDecorator("derslikler", {
                initialValue: ["1101", "1103"],
                rules: [{ required: true, message: "Lüfen derslik seçin!" }]
              })(
                <Checkbox.Group style={{ width: "100%" }}>
                  <Row>
                    <Col span={8}>
                      <Checkbox value="1101">1101</Checkbox>
                    </Col>
                    <Col span={8}>
                      <Checkbox disabled value="1102">
                        1102
                      </Checkbox>
                    </Col>
                    <Col span={8}>
                      <Checkbox value="1103">1103</Checkbox>
                    </Col>
                    <Col span={8}>
                      <Checkbox value="1104">1104</Checkbox>
                    </Col>
                    <Col span={8}>
                      <Checkbox value="Laboratuar-1">Laboratuar-1</Checkbox>
                    </Col>
                  </Row>
                </Checkbox.Group>
              )}
            </Form.Item>
          </Form>
        </Modal>
      );
    }
  }
);
//End: Modal-Form Section for Modified

export default class TblLessons extends Component {
  state = {
    visibleCreate: false,
    visibleModified: false,
    selectedlessonId: -1,
    lessons:[]
  };

  //Begin: Axios-GetLessons
  componentDidMount() {
    Axios.get("https://localhost:44382/api/Ders").then(res => {
      // console.log(res);
      this.setState({ lessons: res.data.entities });
      // console.log(this.state.lessons);
    });
  }
  //End: Axios-GetLessons

  //Begin: Modal-Form Section

  // Begin: Axios-ModifiedLesson

  showModalModified = (prmLessonId) => {
    // console.log(prmLessonId);
    this.setState({
      selectedlessonId : prmLessonId,
      visibleModified: true
    });
  };

  handleCancelModified = () => {
    this.setState({ visibleModified: false, selectedlessonId:-1});
  };

  handleModified = () => {
    const { form } = this.formRefModified.props;
    form.validateFields((err, values) => {
      if (err) {
        return;
      }
      // console.log("Received values of form: ", values);
      //formdan gelen değerler "values" içinde
      try {
        Axios.put(
          "https://localhost:44382/api/Ders/" + this.state.selectedlessonId,
          values
        ).then(response => { 
          this.componentDidMount();
          this.successMessage("İşem başarılı");
          // console.log(response);
        })
        .catch(error => {
            // console.log(error.response.status);
            this.errorMessage("İşem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        });
      } catch (error) {
        this.errorMessage("Lütfen geliştiriciler ile bağlı kurun.", "error");
      }
      form.resetFields();
      this.setState({ visibleModified: false, selectedlessonId:-1});
    });
  };

  modifiedFormRef = formRefModified => {
    this.formRefModified = formRefModified;
  };
  // End: Axios-ModifiedLesson

  //Begin: Axios-RegisterLesson

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
      //değerler "values" içinde
      // console.log("https://localhost:44382/api/Ders/\"ad\":\""+values.ad+"\"");
      try {
        Axios.post("https://localhost:44382/api/Ders", values)
        .then(response => { 
          this.componentDidMount();
          this.successMessage("İşem başarılı");
          // console.log(response);
        })
        .catch(error => {
            // console.log(error.response.status);
            this.errorMessage("İşem başarısız. Lütfen daha sonra tekrar deneyiniz.");
        });
      } catch (error) {
        this.errorMessage("Lütfen geliştiriciler ile bağlı kurun.", "error");
      }
      // console.log("Received values of form: ", values);
      form.resetFields();
      this.setState({ visibleCreate: false });
    });
  };
  //End Axios-RegisterLesson

  saveFormRefCreate = formRefCreate => {
    this.formRefCreate = formRefCreate;
  };
  //End Modal-Form Section

  //Begin:  Modal Message
  successMessage = (prmMessage) => {
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
    return (
      <div>
        <Table dataSource={this.state.lessons} rowKey="id">
          {/* {console.log(this.state.lessons)} */}
          {/* <Column
            title="Id"
            dataIndex="id"
            visible="false"
            // key="createdDate"
          /> */}
          <Column title="Ders Adı" dataIndex="ad" />
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
                    this.showModalModified(record.id);
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
          Yeni Ders
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
