import React, { useState } from 'react'
import styles from './Input.module.scss'
import classNames from 'classnames'

export type CustomInputType =
 | 'email'
 | 'money'
 | 'number'
 | 'password'
 | 'phone'
 | 'text'
 | 'zip'
 | 'date'
 
interface InputProps {
 label?: string
 placeholder?: string
 required?: boolean
 type: CustomInputType
 className?: string
 onChange?: Function
 onBlur?: Function
 value?: string | number | undefined
 onKeyUp?: Function
}
 
const Input: React.FC<InputProps> = props => {
  const {
    label,
    placeholder = label,
    required,
    type,
    className,
    onChange = () => {},
    onBlur = () => {},
    onKeyUp = () => {},
    value
  } = props

  const renderRequiredLabel = (): JSX.Element => (
    <span className='input-required'>*</span>
  )

  const inputID: string = label?.toLowerCase() || ''
  
  return (
    <div className={classNames(styles.inputContainer, className)}>
      {label 
      ?
        <label htmlFor={inputID} className={styles.baseLabel}>
          {label} {required ? renderRequiredLabel() : null}
        </label>
      : <></> 
      }
      <input
        id={inputID}
        type={type}
        name={inputID}
        placeholder={placeholder}
        onChange={(event) => onChange(event.target.value)}
        onBlur={(event) => onBlur(event.target.value)}
        required={required ?? false}
        value={value}
        className={styles.baseInput}
        onKeyUp={(event) => onKeyUp(event)}
      />
    </div>
  )
}
 
export default Input