import axios from 'axios'
import classNames from 'classnames'
import React from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { GostForm, newGostModel } from 'widgets/gost-form'

import styles from './GostReplacePage.module.scss'
import { gostModel } from 'entities/gost'
import { useAxios } from 'shared/hooks'

function getGostStub() {
    return {
        "designation": '',
        "fullName": '',
        "codeOKS": '',
        "activityField": '',
        "acceptanceDate": '',
        "commissionDate":  '',
        "author": '',
        "acceptedFirstTimeOrReplaced": '',
        "content": '',
        "keyWords": '',
        "keyPhrases": '',
        "applicationArea": '',
        "adoptionLevel": 0,
        "documentText": '',
        "changes": '',
        "amendments": '',
        "status": 0,
        "harmonization": 1,
        "isPrimary": true,
        "referencesId": []
    } as newGostModel.GostToSave
}

const GostReplacePage = () => {
    const navigate = useNavigate()
    const gostToReplaceId = useParams().id
    const {response, loading} = useAxios<gostModel.Gost>('localhost:8080/api/docs/' + gostToReplaceId)


    const addNewDocument = (gost: newGostModel.GostToSave) => {
      axios.post('localhost:8080/api/docs/add', gost, {
        headers: {
          Authorization: `Bearer ${localStorage.getItem('jwt_token')}`
        }
      })
      .then(() => {
          axios.put(`localhost:8080/api/docs/change-status`, {
              id: gostToReplaceId,
              status: 2
          }, {
              headers: {
                  Authorization: `Bearer ${localStorage.getItem('jwt_token')}`
              }
          })
      }).then(() => navigate('/'))
    }

      if(loading) return <></>
    
      return (
        <div className='container'>
          <section className={classNames('contentContainer', styles.reviewSection)}>
            <GostForm handleSubmit={addNewDocument} gost={{...getGostStub(), acceptedFirstTimeOrReplaced: `Принят взамен ${response?.primary.designation}`}}/>
          </section>
        </div>
      )
}

export default GostReplacePage